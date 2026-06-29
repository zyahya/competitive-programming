#!/usr/bin/env python3

import argparse
import re
from pathlib import Path


def snake_to_pascal(text: str) -> str:
    """
    snake_case -> PascalCase

    If '__' exists, treat it as a separator that becomes a single '_':
        test_problem__linq -> TestProblem_Linq
    """
    text = text.replace("__", "\0")

    parts = text.split("\0")
    converted = []

    for part in parts:
        words = [w for w in part.split("_") if w]
        converted.append("".join(w.capitalize() for w in words))

    return "_".join(converted)


def update_namespace(content: str, kyu: str, namespace_name: str) -> tuple[str, bool]:
    pattern = re.compile(
        rf"namespace\s+Codewars\.Solutions\.{re.escape(kyu)}\.[A-Za-z0-9_]+;"
    )

    replacement = f"namespace Codewars.Solutions.{kyu}.{namespace_name};"

    new_content, count = pattern.subn(replacement, content, count=1)

    return new_content, count > 0


def process_problem(problem_dir: Path, dry_run: bool):
    old_problem_name = problem_dir.name
    new_problem_name = snake_to_pascal(old_problem_name)

    kyu = problem_dir.parent.name

    print(f"\n[{old_problem_name}]")
    print(f"  Folder: {old_problem_name} -> {new_problem_name}")

    cs_files = sorted(problem_dir.glob("*.cs"))

    for file in cs_files:
        old_name = file.stem
        new_name = snake_to_pascal(old_name) + file.suffix

        print(f"  File:   {file.name} -> {new_name}")

        content = file.read_text(encoding="utf-8")
        new_content, updated = update_namespace(
            content,
            kyu,
            new_problem_name,
        )

        if updated:
            print("          namespace updated")
        else:
            print("          namespace not found")

        if not dry_run:
            if updated and new_content != content:
                file.write_text(new_content, encoding="utf-8")

            if file.name != new_name:
                file.rename(file.with_name(new_name))

    if not dry_run and old_problem_name != new_problem_name:
        problem_dir.rename(problem_dir.with_name(new_problem_name))


def main():
    parser = argparse.ArgumentParser(
        description="Rename Codewars problem folders/files to PascalCase."
    )
    parser.add_argument(
        "path",
        type=Path,
        help="Path to Kyu directory (e.g. Kyu8)",
    )
    parser.add_argument(
        "--dry-run",
        action="store_true",
        help="Show changes without modifying anything.",
    )

    args = parser.parse_args()

    root = args.path.resolve()

    if not root.is_dir():
        raise SystemExit(f"Directory not found: {root}")

    problems = sorted(p for p in root.iterdir() if p.is_dir())

    print("=" * 70)
    print(f"Kyu Directory : {root.name}")
    print(f"Problems      : {len(problems)}")
    print(f"Mode          : {'DRY RUN' if args.dry_run else 'EXECUTE'}")
    print("=" * 70)

    for problem in problems:
        process_problem(problem, args.dry_run)

    print("\nDone.")


if __name__ == "__main__":
    main()
