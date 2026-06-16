# Competitive Programming

This repo contains all my solutions to all coding problems I've solved.

Quick Links:

- [LeetCode](./leetcode/README.md)
- [Codewars](./codewars/README.md)
- [HackerRank](./hackerrank/README.md)

# My Typical Workflow

I solve problems in multiple different platforms in different languages, but mainly I use C#.

The entire structure as follows:

```
platform/
├── language/
│  ├── problem_name/
│  │    ├── problem_name.cs
│  │    ├── problem_name_other_solution.cs
│  │    ├── problem_name_tests
│  │    └── README.md
│  ├── .editorconfig
│  ├── .gitignore
│  ├── template.sh
│  └── README.md
├── README.md
└── generate_solutions_table.py

other platforms/
└── .../
```

Rules:

- Each problem has its own directory, contains the following:
  - Solutions files
  - One test file
  - README.md
- Files names are all in snake_case in the following standard:
  - If there only one solution: `problem_name`
  - If there are multiple solutions: `problem_name_solution_title`
  - Test files must ends with `tests`.

Example:

```
leetcode/
└── csharp/
   └── q125_valid_palindrome/
        ├── q125_valid_palindrome_string_builder.cs
        ├── q125_valid_palindrome_skip_non_alphabetical.cs
        ├── q125_valid_palindrome_tests
        └── README.md
```
