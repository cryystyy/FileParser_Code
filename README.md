# FileParser_Code
Need to create console app, that:  
1. Takes next params: start directory, action name, path to file with results (by default results.txt).  
2. Walks through all folders and subfolders and for each file, depending on action name:      
  a. all - for all files remembers path to file, relatively to parameter “start folder”      
  b. cs - for all files with extension cs (*.cs) remembers path to file, relatively to parameter “start folder”, and adds string " /".     
  c. reversed1 - for all files remembers path to file, relatively to parameter “start folder”, but string path should be changed in the        way to read it from file name to parent folder (for example, f\bla\ra\t.dat -> t.dat\ra\bla\f).      
  d. reversed2 - for all files remembers path to file, relatively to parameter “start folder”, but string path should be inverted (for          example, f\bla\ra\t.dat -> tad.t\ar\alb\f).  
3. All data should be written to the text file with results, each line contains processed file path.   

Example of use: _toolname.exe c:\some-dir all 
Implement using OOP approach with separate classes, which implements one interface.  
Any nuget libraries can be used. Write necessary unit tests. 
Use Dependency injection (using any DI Container is required). Walking through folders should be asynchronous (async/await). 
Implement cancellation by user input.
