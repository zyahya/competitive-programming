Using the garbage collector before returning the value in the optimized solution, decreases the memory usage by ~15% but increases the runtime from 1ms to 6ms!

```cs
GC.Collect();
```
