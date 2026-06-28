Two approaches to solve this problem:

1. Filter the input first

```
1. Initialize an empty string called filter
2. Traverse every char in the original string
    3. If the char between range a-z/A-Z
        4. Add it to the filtered string
5. Initialize left and right pointers according to the filtered string
6. If the filtered string is empty return true
7. Traverse every character until left <= right, means no letters between anymore
    8. If left char != right char
        9. Return false; otherwise increase left toward and decrease right backward
10. Return true; as all chars pass the check
```

```
0p  -> p -> false
0p0 -> p -> true
0p1 -> p -> false
```
