#!/usr/bin/env bash

dotnet new class --name "$1" --output "./HackerRank.Solutions/$1"
touch ./HackerRank.Solutions/$1/README.md

dotnet new class --name "$1"Tests --output "./HackerRank.Tests/"$1"Tests"

# Fix the namespace in the generated file
sed -i "s/namespace HackerRank.Solutions;/namespace HackerRank.Solutions.$1;/" "./HackerRank.Solutions/$1/$1.cs"

sed -i "s/namespace HackerRank.Tests;/namespace HackerRank.Tests."$1"Tests;/" "./HackerRank.Tests/"$1"Tests/"$1"Tests.cs"
