#!/usr/bin/env bash

PROBLEM_NAME="$1"

# Function to force strings into PascalCase for the C# Class Names
to_pascal_case() {
    echo "$1" | sed -E 's/[_-]+/ /g' | awk '{for(i=1;i<=NF;i++) sub(/./,toupper(substr($i,1,1)),$i)}1' | sed 's/ //g'
}

# 1. Convert to PascalCase (e.g. 8-square-n-sum -> 8SquareNSum)
CLASS_NAME=$(to_pascal_case "$PROBLEM_NAME")

# 2. Inject underscore after the problem number (e.g., 8SquareNSum -> 8_SquareNSum or Q485Max -> Q485_Max)
CLASS_NAME=$(echo "$CLASS_NAME" | sed -E 's/^([Qq]?[0-9]+)_?([A-Za-z])/\1_\2/')

# Keep directory and file names EXACTLY as the user input
TARGET_DIR="./$PROBLEM_NAME"

mkdir -p "$TARGET_DIR"
touch "$TARGET_DIR/README.md"

# Generate the Solution Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}.cs" <<EOF
namespace LeetCode.Solutions.${PROBLEM_NAME};

public class ${CLASS_NAME}
{
    public static int Solution()
    {

        return 0;
    }
}
EOF

# Generate the Test Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}_tests.cs" <<EOF
namespace LeetCode.Solutions.${PROBLEM_NAME};

public class ${CLASS_NAME}_Tests
{
    [Fact]
    public void ${CLASS_NAME}_Solution_1()
    {
        // var result = ${CLASS_NAME}.Solution();

        // Assert.Equal(expectedResult, result);
    }
}
EOF

echo "Generated structure at: $TARGET_DIR"
