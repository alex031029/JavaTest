# CAP
1. consistency
2. availability 
3. tolerance to network partitions

# Mapreduce

1. Input, split, map, shuffle, reduce, finalize
2. Can only be applied for project that 
	* Offline
	* Insensitive to speed
	* Batch processing

# Hadoop

1. HDFS: Hadoop distributed file system

# Spark

1. Based on memory computation (faster than MapReduce)
2. Many nodes are virtual nodes, which can be within a same machine
3. Many operations can be used as memory, and many operations can be omitted.
4. In comparision, MapReduce has very strict computing methodology.

# Hive
1. Data warehouse

# YARN

1. resource manager
2. node manager
3. application master

# Redis
1. A kind of NoSql (key-value database)
2. KV + cache + persistence

# Kafka
1. A distributed message queue, or stream processing platform
2. High robust, redundance, async communication 
3. producer: send out message
4. consumer: receive message
5. depend on **zookeeper** to store meta info
