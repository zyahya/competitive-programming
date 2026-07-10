#!/usr/bin/env bash

LEVEL="$1"
PROBLEM_NAME="$2"

if [[ -z "$LEVEL" || -z "$PROBLEM_NAME" ]]; then
    echo "Usage: $0 <LevelNumber> <ProblemName>"
    echo "Example: $0 8 square-n-sum"
    exit 1
fi

# Normalize common level aliases like 8, 8kyu, or Kyu8 -> kyu8
if [[ "$LEVEL" =~ ^([0-9]+)$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
elif [[ "$LEVEL" =~ ^([0-9]+)[Kk]yu$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
elif [[ "$LEVEL" =~ ^[Kk]yu([0-9]+)$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
fi

# Function to force strings into PascalCase for the C# Class Names
to_pascal_case() {
    echo "$1" | sed -E 's/[_-]+/ /g' | awk '{for(i=1;i<=NF;i++) sub(/./,toupper(substr($i,1,1)),$i)}1' | sed 's/ //g'
}

CLASS_NAME=$(to_pascal_case "$PROBLEM_NAME")

# Keep directory and file names EXACTLY as the user input
TARGET_DIR="./$LEVEL/$PROBLEM_NAME"

mkdir -p "$TARGET_DIR"
touch "$TARGET_DIR/README.md"

# Generate the Solution Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}.cs" <<EOF
namespace Codewars.Solutions.${LEVEL}.${PROBLEM_NAME};

public class ${CLASS_NAME}
{
    public static void Solution()
    {

    }
}
EOF

# Generate the Test Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}_Tests.cs" <<EOF
namespace Codewars.Solutions.${LEVEL}.${PROBLEM_NAME};

public class ${CLASS_NAME}Tests
{
    [Fact]
    public void Test1()
    {
        // var result = ${CLASS_NAME}.Solution();

        // Assert.Equal();
    }
}
EOF

echo "Generated structure at: $TARGET_DIR"
