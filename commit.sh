#!/bin/bash

if [ "$#" -ne 2 ]; then
    echo "Usage: commit <new | opt | ref | fix | alt> <file_path>"
    echo "  new : New problem"
    echo "  opt : Optimize existing solution"
    echo "  ref : Refactor existing solution"
    echo "  fix : Fix existing solution"
    echo "  alt : Add another solution to existing problem, only if technique specified"
    exit 1
fi

OPERATION=$1
FILE_PATH=$2

if [ ! -f "$FILE_PATH" ]; then
    echo "Error: File '$FILE_PATH' does not exist."
    exit 1
fi

BASE_NAME=$(basename "$FILE_PATH")
DIR_NAME=$(dirname "$FILE_PATH")

EXTENSION="${BASE_NAME##*.}"

if [[ "$BASE_NAME" == *__* ]]; then
    PROBLEM_NAME="${BASE_NAME%%__*}"
    TECHNIQUE="${BASE_NAME#*__}"

    TECHNIQUE="${TECHNIQUE%.*}"

    PROBLEM_DISPLAY=$(echo "$PROBLEM_NAME" | tr '_' ' ')
    TECHNIQUE_DISPLAY=$(echo "$TECHNIQUE" | tr '_' ' ')
else
    TECHNIQUE_DISPLAY=""
    PROBLEM_NAME="${BASE_NAME%.*}"
    PROBLEM_DISPLAY=$(echo "$PROBLEM_NAME" | tr '_' ' ')
fi

case "$EXTENSION" in
    c)   LANG_NAME="C" ;;
    cpp)  LANG_NAME="C++" ;;
    cc)  LANG_NAME="C++" ;;
    cs)   LANG_NAME="C#" ;;
    py)   LANG_NAME="Python" ;;
    js)   LANG_NAME="JavaScript" ;;
    ts)   LANG_NAME="TypeScript" ;;
    java) LANG_NAME="Java" ;;
    go)   LANG_NAME="Go" ;;
    rs)   LANG_NAME="Rust" ;;
    sql)   LANG_NAME="SQL" ;;
    sh)   LANG_NAME="Bash" ;;
    *)    LANG_NAME="${EXTENSION^^}" ;;
esac

TEST_FILE="${DIR_NAME}/${PROBLEM_NAME}_tests.${EXTENSION}"

if [ ! -f "$TEST_FILE" ]; then
    echo "Warning: Test file '$TEST_FILE' not found. Only the solution file will be staged."
    TEST_FILE=""
fi

README="${DIR_NAME}/README.md"

if [ ! -f "$README" ]; then
    echo "Warning: Test file '$README' not found. Only the solution file will be staged."
    README=""
fi

git add "$FILE_PATH"
if [ -n "$TEST_FILE" ]; then
    git add "$TEST_FILE"
fi

if [ -n "$README" ]; then
    git add "$README"
fi

if [[ -z "$TECHNIQUE_DISPLAY" ]]; then
    case "$OPERATION" in
        new)
            COMMIT_MSG="solve '$PROBLEM_DISPLAY'"
            ;;
        opt)
            COMMIT_MSG="optimize '$PROBLEM_DISPLAY'"
            ;;
        ref)
            COMMIT_MSG="refactor '$PROBLEM_DISPLAY'"
            ;;
        fix)
            COMMIT_MSG="fix '$PROBLEM_DISPLAY'"
            ;;
        *)
            echo "Error: Invalid operation '$OPERATION'."
            exit 1
            ;;
    esac
else
    case "$OPERATION" in
        new)
            COMMIT_MSG="solve '$PROBLEM_DISPLAY' using $TECHNIQUE_DISPLAY"
            ;;
        opt)
            COMMIT_MSG="optimize '$PROBLEM_DISPLAY' ($TECHNIQUE_DISPLAY solution)"
            ;;
        ref)
            COMMIT_MSG="refactor '$PROBLEM_DISPLAY' ($TECHNIQUE_DISPLAY solution)"
            ;;
        fix)
            COMMIT_MSG="fix '$PROBLEM_DISPLAY' ($TECHNIQUE_DISPLAY solution)"
            ;;
        alt)
            COMMIT_MSG="add alternative $TECHNIQUE_DISPLAY solution for '$PROBLEM_DISPLAY'"
            ;;
        *)
            echo "Error: Invalid operation '$OPERATION'."
            exit 1
            ;;
    esac
fi


git commit -m "${COMMIT_MSG} in ${LANG_NAME}"
