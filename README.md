# GradientDescent
An application of Inverse Kinematics to produce an animation using the Gradient Descent method.

The methods used implement an Adaptive Learning Rate, a Momentum implementation, and full implementation of Math and Geometry libraries from scratch.

The visuals intend to represent Dr. Octopus catching Spiderman.

There are several notable limitations: 
- The joints have a maximal range of movement, which tends to fall into local minima because the joints cannot rotate in the gradient's direction.
- The arms have a length that is too large to allow for particularly precise movements.
- The different axes of rotation of the joints make it difficult for the Gradient Descent method to be precise enough, and local minima are easier to fall into.
Nonetheless, the result is quite satisfactory, resulting in relatively smooth movements with the minimum usually being the expected result. The performance is also nice and all methods are fully custom from scratch.
