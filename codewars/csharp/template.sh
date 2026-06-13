#!/usr/bin/env bash

LEVEL="$1"
PROBLEM_NAME="$2"

if [[ -z "$LEVEL" || -z "$PROBLEM_NAME" ]]; then
    echo "Usage: $0 <LevelNumber> <ProblemName>"
    echo "Example: $0 8 SquareNSum"
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

# Convert PascalCase to snake_case for the directory and namespace
# e.g., SquareNSum -> square_n_sum
DIR_NAME=$(echo "$PROBLEM_NAME" | sed -E 's/([A-Z])/_\1/g' | sed 's/^_//' | tr '[:upper:]' '[:lower:]')

# Define target path based on the clean 3-level directory layout
TARGET_DIR="./$LEVEL/$DIR_NAME"

mkdir -p "$TARGET_DIR"
touch "$TARGET_DIR/README.md"

# Generate the Solution Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}.cs" <<EOF
namespace Codewars.Solutions.${LEVEL}.${DIR_NAME};

public class ${PROBLEM_NAME}
{

}
EOF

# Generate the Test Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}Tests.cs" <<EOF
namespace Codewars.Solutions.${LEVEL}.${DIR_NAME};

public class ${PROBLEM_NAME}Tests
{
    [Fact]
    public void Test1()
    {

    }
}
EOF

echo "Generated structure at: $TARGET_DIR"
