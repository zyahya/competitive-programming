#!/bin/bash

declare -A LANGUAGES=(
    [c]="C" [cpp]="C++" [cc]="C++" [cs]="C#" [py]="Python"
    [js]="JavaScript" [ts]="TypeScript" [java]="Java" [go]="Go"
    [rs]="Rust" [sql]="SQL" [sh]="Bash"
)

get_lang_name() {
    local ext=$1
    echo "${LANGUAGES[$ext]:-${ext^^}}"
}

parse_file_path() {
    local file_path=$1
    local base_name=$(basename "$file_path")

    if [[ "$base_name" == *__* ]]; then
        PROBLEM_NAME="${base_name%%__*}"
        local tech="${base_name#*__}"
        TECHNIQUE_DISPLAY=$(echo "${tech%.*}" | tr '_' ' ')
    else
        PROBLEM_NAME="${base_name%.*}"
        TECHNIQUE_DISPLAY=""
    fi
    PROBLEM_DISPLAY=$(echo "$PROBLEM_NAME" | tr '_' ' ')
}

build_commit_msg() {
    local op=$1
    local prob=$2
    local tech=$3

    case "$op" in
        new) echo "solve '$prob'$( [ -n "$tech" ] && echo " using $tech" )" ;;
        opt) echo "optimize '$prob'$( [ -n "$tech" ] && echo " ($tech solution)" )" ;;
        ref) echo "refactor '$prob'$( [ -n "$tech" ] && echo " ($tech solution)" )" ;;
        fix) echo "fix '$prob'$( [ -n "$tech" ] && echo " ($tech solution)" )" ;;
        doc) echo "update README $( [ -n "$tech" ] && echo "of $tech solution " )for '$prob'" ;;
        alt) [ -n "$tech" ] && echo "add alternative $tech solution for '$prob'" || exit 1 ;;
        *) echo "Error: Invalid operation '$op'."; exit 1 ;;
    esac
}

if [ "$#" -ne 2 ]; then
    echo "Usage: commit <new | opt | ref | fix | alt | doc> <file_path>"
    exit 1
fi

OPERATION=$1
FILE_PATH=$2

[ ! -f "$FILE_PATH" ] && { echo "Error: File '$FILE_PATH' does not exist."; exit 1; }

parse_file_path "$FILE_PATH"
LANG_NAME=$(get_lang_name "${FILE_PATH##*.}")

COMMIT_MSG=$(build_commit_msg "$OPERATION" "$PROBLEM_DISPLAY" "$TECHNIQUE_DISPLAY")

git add "$FILE_PATH"
[ -f "${FILE_PATH%%.*}_tests.${FILE_PATH##*.}" ] && git add "${FILE_PATH%%.*}_tests.${FILE_PATH##*.}"
[ -f "$(dirname "$FILE_PATH")/README.md" ] && git add "$(dirname "$FILE_PATH")/README.md"

git commit -m "${COMMIT_MSG} in ${LANG_NAME}"
