#!/usr/bin/env python3
import os
import re
from pathlib import Path

# --- CONFIGURATION ---
README_PATH = Path("README.md")
START_MARKER = "<!-- start table -->"
END_MARKER = "<!-- end table -->"

# 1. Global Ignore List: Any directory or file matching these names will be skipped completely, anywhere they appear
GLOBAL_IGNORE = {
    ".git", ".github", ".vscode", "bin", "obj", ".pytest_cache"
}

# Language mapping for clean UI display
LANGUAGE_MAPPING = {
    "csharp": "C#",
    "python": "Python",
    "javascript": "JavaScript",
    "typescript": "TypeScript",
    "cpp": "C++",
    "dsa-csharp": "DSA in C#",
    "c": "C"
}

# 2. Dynamic Platform Configuration Object
# Controls: Display Label, Folder Scan Depth (3 or 4), and Category/Difficulty sorting priority
PLATFORM_CONFIG = {
    "leetcode": {
        "display_name": "LeetCode",
        "levels": 3,  # Structure: website/lang/solution
        "sort_key": lambda cat: cat  # Simple alphabetical fallback
    },
    "hackerrank": {
        "display_name": "HackerRank",
        "levels": 3,  # Structure: website/lang/solution
        "sort_key": lambda cat: cat  # Simple alphabetical fallback
    },
    "neetcode": {
        "display_name": "NeetCode",
        "levels": 3,  # Structure: website/lang/solution
        "sort_key": lambda cat: cat  # Simple alphabetical fallback
    },
    "codewars": {
        "display_name": "Codewars",
        "levels": 4,  # Structure: website/lang/difficulty/solution
        "sort_key": lambda cat: int(re.search(r'\d+', cat).group()) if re.search(r'\d+', cat) else 99  # kyu1 before kyu8
    }
}


def should_ignore(path: Path) -> bool:
    """Checks if a path contains any globally ignored folder or file segments."""
    return any(part in GLOBAL_IGNORE for part in path.parts)


def get_solutions_data():
    """Scans the repository and dynamically adjusts parsing depth based on PLATFORM_CONFIG."""
    solutions = {}
    root = Path(".")

    # Level 1: Loop through potential Website/Platform directories at root
    for platform_dir in root.iterdir():
        if not platform_dir.is_dir() or should_ignore(platform_dir):
            continue

        platform_key = platform_dir.name.lower()
        if platform_key not in PLATFORM_CONFIG:
            continue  # Skip directories not explicitly defined in our platform config

        config = PLATFORM_CONFIG[platform_key]
        platform_name = config["display_name"]

        if platform_name not in solutions:
            solutions[platform_name] = {}

        # Level 2: Loop through Programming Languages
        for lang_dir in platform_dir.iterdir():
            if not lang_dir.is_dir() or should_ignore(lang_dir):
                continue

            lang_key = lang_dir.name.lower()
            lang_name = LANGUAGE_MAPPING.get(lang_key, lang_dir.name.title())

            if lang_name not in solutions[platform_name]:
                solutions[platform_name][lang_name] = {}

            # Parse depending on the specified depth level strategy
            if config["levels"] == 4:
                # Level 3: Difficulty / Category Folder
                for cat_dir in lang_dir.iterdir():
                    if not cat_dir.is_dir() or should_ignore(cat_dir):
                        continue

                    cat_name = cat_dir.name
                    if cat_name not in solutions[platform_name][lang_name]:
                        solutions[platform_name][lang_name][cat_name] = []

                    # Level 4: Actual Solutions
                    for prob_dir in cat_dir.iterdir():
                        if not prob_dir.is_dir() or should_ignore(prob_dir):
                            continue

                        add_problem(solutions[platform_name][lang_name][cat_name], prob_dir)

            elif config["levels"] == 3:
                # Level 3: Direct Solutions (Flat category used as a placeholder key)
                cat_name = "All Solutions"
                if cat_name not in solutions[platform_name][lang_name]:
                    solutions[platform_name][lang_name][cat_name] = []

                for prob_dir in lang_dir.iterdir():
                    if not prob_dir.is_dir() or should_ignore(prob_dir):
                        continue

                    add_problem(solutions[platform_name][lang_name][cat_name], prob_dir)

    return solutions


def add_problem(target_list, prob_dir: Path):
    """Formats and appends solution metadata to the tracking array."""
    prob_title = prob_dir.name.replace("_", " ").replace("-", " ").title()
    # Normalize clean paths for markdown links (e.g., ./leetcode/csharp/q485_max...)
    rel_path = f"./{'/'.join(prob_dir.parts)}/"

    target_list.append({
        "title": prob_title,
        "path": rel_path
    })


def build_markdown_tables(solutions):
    """Generates complete Markdown dynamically altering heading levels depending on configured structure rules."""
    markdown_lines = []

    # Sort Website/Platforms alphabetically
    for platform in sorted(solutions.keys()):
        markdown_lines.append(f"## {platform}\n")  # Platform Header (H2)
        platform_key = platform.lower()
        config = PLATFORM_CONFIG[platform_key]

        # Sort Languages alphabetically
        for lang in sorted(solutions[platform].keys()):
            markdown_lines.append(f"### {lang}\n")  # Language Header (H3)

            # Sort categories according to custom sorting logic rule configured in platform settings
            categories = sorted(solutions[platform][lang].keys(), key=config["sort_key"])

            for cat in categories:
                problems = solutions[platform][lang][cat]
                if not problems:
                    continue

                # Heading adjustments: Only output Category sub-headers (H4) if it's a true 4-level layout
                if config["levels"] == 4:
                    markdown_lines.append(f"#### {cat}\n")
                    markdown_lines.append("| Problem | Level | Solution |")
                    markdown_lines.append("| :--- | :---: | :--- |")

                    sorted_probs = sorted(problems, key=lambda x: x["title"])
                    for prob in sorted_probs:
                        markdown_lines.append(f"| {prob['title']} | {cat} | [Solution]({prob['path']}) |")
                else:
                    # 3-level flat table layout
                    markdown_lines.append("| Problem | Solution |")
                    markdown_lines.append("| :--- | :--- |")

                    sorted_probs = sorted(problems, key=lambda x: x["title"])
                    for prob in sorted_probs:
                        markdown_lines.append(f"| {prob['title']} | [Solution]({prob['path']}) |")

                markdown_lines.append("")  # Spacing between tables

    return "\n".join(markdown_lines).strip()


def update_readme(new_markdown):
    """Injects generated layout content inside README.md target tags safely."""
    if not README_PATH.exists():
        default_structure = f"# Monorepo Code Solutions\n\n{START_MARKER}\n{END_MARKER}\n"
        README_PATH.write_text(default_structure, encoding="utf-8")

    content = README_PATH.read_text(encoding="utf-8")
    pattern = re.compile(f"{re.escape(START_MARKER)}.*{re.escape(END_MARKER)}", re.DOTALL)
    replacement = f"{START_MARKER}\n\n{new_markdown}\n\n{END_MARKER}"

    if START_MARKER in content and END_MARKER in content:
        updated_content = pattern.sub(replacement, content)
    else:
        updated_content = f"{content}\n\n## Solutions Matrix\n{replacement}"

    README_PATH.write_text(updated_content, encoding="utf-8")
    print("README.md indexed successfully!")


if __name__ == "__main__":
    data = get_solutions_data()
    md_tables = build_markdown_tables(data)
    update_readme(md_tables)
