import argparse
import os
import re
from pathlib import Path


def pascal_to_snake(name: str) -> str:
    """Converts a PascalCase string to snake_case.

    Example: 'MyAwesomeFile' -> 'my_awesome_file'
    """
    # Insert an underscore before any capital letter followed by a lowercase letter
    s1 = re.sub("(.)([A-Z][a-z]+)", r"\1_\2", name)
    # Insert an underscore between a lowercase letter/number and a capital letter
    s2 = re.sub("([a-z0-9])([A-Z])", r"\1_\2", s1)
    return s2.lower()


def rename_files(target_dir: str, dry_run: bool = True):
    """Walks through directories and renames PascalCase files to snake_case."""
    root_path = Path(target_dir)

    if not root_path.exists():
        print(f"Error: The directory '{target_dir}' does not exist.")
        return

    print(
        f"Starting process in: {root_path.resolve()}"
        f" {'[DRY RUN - No changes will be made]' if dry_run else '[ACTUAL RUN - Renaming files]'}"
    )
    print("-" * 60)

    rename_count = 0
    skipped_count = 0

    # rglob("*") recursively finds all files and directories
    # We sort by depth (longest paths first) to prevent breaking directory loops if we rename folders later,
    # though this script specifically targets file names.
    for path in sorted(root_path.rglob("*"), key=lambda p: len(p.parts), reverse=True):
        # Only target files, skip directories
        if not path.is_file():
            continue

        # Skip README.md (case-insensitive check)
        if path.name.lower() == "readme.md":
            skipped_count += 1
            continue

        # Separate the stem (filename) from the suffix (.ext)
        file_stem = path.stem
        file_suffix = path.suffix

        # Convert stem to snake_case
        new_stem = pascal_to_snake(file_stem)
        new_name = f"{new_stem}{file_suffix}"

        # If the name actually changed, proceed
        if new_name != path.name:
            new_path = path.with_name(new_name)

            if dry_run:
                print(f"[DRY RUN] Would rename: {path.relative_to(root_path)}")
                print(f"                  to: {new_path.relative_to(root_path)}")
            else:
                try:
                    path.rename(new_path)
                    print(f"[RENAMED] {path.relative_to(root_path)} -> {new_name}")
                except Exception as e:
                    print(f"[ERROR] Failed to rename {path.name}: {e}")

            rename_count += 1

    print("-" * 60)
    if dry_run:
        print(f"Dry run complete. Would rename {rename_count} files. (Skipped {skipped_count} READMEs)")
    else:
        print(f"Actual run complete. Successfully renamed {rename_count} files. (Skipped {skipped_count} READMEs)")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(
        description="Rename files from PascalCase to snake_case recursively."
    )
    parser.add_argument(
        "directory",
        nargs="?",
        default=".",
        help="The target root directory to scan (default: current directory)",
    )
    parser.add_argument(
        "--run",
        action="store_true",
        help="Execute the actual renaming. If omitted, defaults to a safe dry run.",
    )

    args = parser.parse_args()

    # The script defaults to dry_run=True unless --run is explicitly passed
    rename_files(target_dir=args.directory, dry_run=not args.run)