#!/usr/bin/env bash

INPUT_NAME="$1"

if [[ -z "$INPUT_NAME" ]]; then
    echo "Usage: $0 <ProblemName>"
    echo "Example: $0 Q485MaxConsecutiveOnes"
    exit 1
fi

# 1. Force PascalCase (e.g., q485_max_consecutive_ones or Q485MaxConsecutiveOnes -> Q485MaxConsecutiveOnes)
# Note: updated to match both upper and lower case after hyphens/underscores for robustness
PROBLEM_NAME=$(echo "$INPUT_NAME" | sed -E 's/(_|-)([a-zA-Z])/\U\2/g; s/^[a-z]/\U&/')

# 2. Inject underscore after the Question Number (e.g., Q485MaxConsecutiveOnes -> Q485_MaxConsecutiveOnes)
PROBLEM_NAME=$(echo "$PROBLEM_NAME" | sed -E 's/^(Q[0-9]+)_?([A-Za-z])/\1_\2/')

# 3. Force snake_case for the Directory and Namespace (e.g., Q485_Max... -> q485_max...)
# The final `sed` cleans up any double underscores that might occur from the step above
DIR_NAME=$(echo "$PROBLEM_NAME" | sed -E 's/([A-Z])/_\1/g' | sed 's/^_//' | tr '[:upper:]' '[:lower:]' | sed -E 's/__+/_/g')

# Target directory is directly inside the current language folder
TARGET_DIR="./$DIR_NAME"

mkdir -p "$TARGET_DIR"
touch "$TARGET_DIR/README.md"

# Generate the Solution Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}.cs" <<EOF
namespace LeetCode.Solutions.${DIR_NAME};

public class ${PROBLEM_NAME}
{

}
EOF

# Generate the Test Boilerplate
cat > "$TARGET_DIR/${PROBLEM_NAME}Tests.cs" <<EOF
namespace LeetCode.Solutions.${DIR_NAME};

public class ${PROBLEM_NAME}Tests
{
    [Fact]
    public void Test1()
    {

    }
}
EOF

echo "Generated LeetCode structure at: $TARGET_DIR"
