# Interesting-dynamic-fractals
Two cool functions for drawing beautiful fractals
#
The first is kind of classic, it is the drawing for the proof of the Pythagorean theorem. We have 2 main inputs, the length of the size and the ratio r, where r represents the ratio (left part of hypotenuse after height is dropped)/(length of hypotenuse). If the ratio is 0.5, we get perfectly symmetrical drawing, in the other case it curves in one direction. There is also an option to rotate the entire tree at an angle counterclockwise.
<img width="1075" height="413" alt="Pyt Tree both" src="https://github.com/user-attachments/assets/dbbe5282-df44-4025-95c4-a6a82afeabcc" />
#
The second fractal is my implementation. We take a circle and draw the diameter. Then, we take the intersection points of the diameter and the circle and choose them for two centers of two new circles with half the radius that will continue the recursion. And it perfectly illustrates the proggression 1/2+1/4+1/8+... = 1 and both recursions approach/meet exactly at the center. This is the DrawC method and we again have the option to rotate counterclockwise.
<img width="992" height="525" alt="DrawC" src="https://github.com/user-attachments/assets/ada8caa6-69ae-4618-8346-d7231c23bd6c" />
#
Then, we continue. We add the option to keep rotating the fractal and switch colours after each iteration. It is hard to represent the animation with only one picture, you have to run the code yourself to appreciate it more. And finally, I added a last variable R, standing for radius. Before the rotation was with fixed center, but now we start to move it. The drawing goes in a semicircular path, then goes 45 degrees up to the left, or in North-West direction, just for fun.
<img width="817" height="725" alt="DrawCR" src="https://github.com/user-attachments/assets/53acf64f-6f19-4ba6-b792-2beb8bc6fc40" />
<img width="1147" height="831" alt="DrawCR with radius" src="https://github.com/user-attachments/assets/6ed82d21-08db-4403-9059-a42c8c81a15b" />




