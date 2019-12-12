1. Fully connected feedfoward network
2. Goodness: use cross entropy
3. Backpropogation:
	* calculate the partial deriviates

4. Do no always blame overfitting in deep learning
	* Dropout: good for testing data
			

5. Methods for poor performance:
	* change activation function 
		* vanishing gradient problem: happens when using sigmoid function
		* other options: ReLU
	* early stop
	* regularization
	* dropout
	* adaptive learning rate

6. CNN
	* properties
		* some patterns are much smaller than the image
		* some pattern appears in different regions
		* subsampling the pixels does not change the object
	* convolution layer and max pooling layer
		* max pooling is not compulsory, and it can be changed to other pooling function
	* less parameters!
