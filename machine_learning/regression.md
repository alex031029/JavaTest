# Notes for Machine Learning

1. Regularization
	* A method to avoid overfitting
	* $E(\theta) = L(thetha) + \lambda\cdot\sum (w_i)$
	* where $L$ is the loss function, $\theta$ is all input variants and $w_i$ is all weights.
	* It can make the regression function more smooth.
2. Error is from 
	* bias
		* estimator can be biased!
		* the average of all estimators from different universes (sample sets) could be more unbiased 
	* variance
		* the difference from a variant to the center of estimator.
	* a simple estimator has a larger bias, but a smaller variance. 
	* Error mainly comes from variance is called **overfitting**
	* Error mainly comes from bias is called **underfitting**
3. Methods for **underfitting**
	* consider more parameters
	* make the model more complex
4. Methods for **overfitting**
	* more data
		* not always practical, you can 数据增强
	* regularization 

5. Gradient Descent
	* tuning your learning rate
	* adaptive learning rate
		* reduce the learning rate when approaching the destination
	* AdaGrad 
		* divide the learning rate of each parameter by the root mean square of its previous derivatives.i
		* The best step is $|first derivative|/second derivative $
		* It estimates the value of second derivative
	* **Limitation**
		* stay in local minima and saddle point
		* very slow in plateau
6. Stochastic Gradient Descent
	* only consider one example for each iteration. 
	* it is faster
.
