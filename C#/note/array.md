# 多维数组 

英文就是multidimensional array，我们平时在其他语言（比如C++）里面的多维数组。
比如一个二维int型数组声明如下

  int [ , ] m = new int[10,30];
  
# 交错数组

英文叫jagged array。本意是数组的数组。
含义上更像是C++里的vector嵌套，好像是`vector<vector<int>>`这样的感觉。
所以一个交错数组中的数组，并不会保证都是一样长度，这点也与vector嵌套一致。
比如一个二维int型交错数组声明如下：

  int[][] jaggedArray = new int[5][];
  jaggedArray[0] = { 1, 2, 3 }; // 3 item array
  jaggedArray[1] = new int[10]; // 10 item array
  // etc.
