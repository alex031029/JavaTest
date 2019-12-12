1. std::map
	* HashMap: most used one. Only one record can has a key of NULL.
	* TreeMap: it can store the records in order of key (default: ascending). When using a iterator to tranvers a TreeMap, the returned result is ordered. Not key can be NULL.
	* HashTable: similar to HashMap. Both key and value cannot be NULL. It supports synchronization of multithreads. In other word, only one thread can write a HashTable at a given time.
	* LinkedHashMap: Record the order of inputs. 
