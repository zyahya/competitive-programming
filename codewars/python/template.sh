#!/usr/bin/env bash

LEVEL="$1"
PROBLEM_NAME="$2"

if [[ -z "$LEVEL" || -z "$PROBLEM_NAME" ]]; then
    echo "Usage: $0 <LevelNumber> <ProblemName>"
    echo "Example: $0 8 square_n_sum"
    exit 1
fi

if [[ "$LEVEL" =~ ^([0-9]+)$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
elif [[ "$LEVEL" =~ ^([0-9]+)[Kk]yu$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
elif [[ "$LEVEL" =~ ^[Kk]yu([0-9]+)$ ]]; then
    LEVEL="kyu${BASH_REMATCH[1]}"
fi

TARGET_DIR="./$LEVEL/$PROBLEM_NAME"

mkdir -p "$TARGET_DIR"
touch "$TARGET_DIR/README.md"
touch "$TARGET_DIR/__init__.py"

cat > "$TARGET_DIR/${PROBLEM_NAME}.py" <<EOF
def solution():

    pass
EOF

cat > "$TARGET_DIR/${PROBLEM_NAME}_tests.py" <<EOF
from .${PROBLEM_NAME} import solution
import pytest


def test_${PROBLEM_NAME}():
    # assert solution() is
	pass
EOF

echo "Generated structure at: $TARGET_DIR"
