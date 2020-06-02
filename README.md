# pace-2020
TREEDEPTH
GenSol.exe - Program for Treedepth decomposition of connected graphs.
Used Language: C#
No external libraries
Open Source code - GNU GPL v3 Licence

System requirements:
x86-64 CPU
Operation System - Windows XP - Windows 10; Linux or other Unix-based OS.
64 Mb RAM or more. RAM size depends on graph size you want to calculate.

Link for description of the Program - 

PROGRAM INPUT
To use the Program start GenSol.exe and enter Graph for solving on console.
The firsy string should be:

p tdp V E

Where
V - The number of Vertex of Graph
E - The number of Lines of Graph.

Then begin entering pairs of vertex of Graph. One pair per string. Vertex separated by space.
For example:

1 2

Where '1' is one vertex, '2' is another vertex, which is connected in Graph.

PROGRAM OUTPUT
When calculation is finished the Program will show you the result in console.
For example, the following file

3
2
3
0
3
4

corresponds to the tree:

    3
   / \
  2   4
 /     \ 
1       5

The first string in file shows the depth of a tree.
Otherwise, the number in the (i+1)-th line denotes the parent of vertex i in the tree.
