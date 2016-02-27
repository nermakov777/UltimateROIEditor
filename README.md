# UltimateROIEditor
2D vector graphics editor

Product name: Ultimate ROI Editor


Working name: Razmechatel (in russian)


Author: Ermakov Nikita Vladimirovich


Created: 02/11/2016


Platform: С#, .NET, Visual Studio 2013


Current development stage: pre-pre-alpha


Main field of application: computer vision


Purposes: mark up different shapes on image, manual mark up edges of objects


Description:


Simple 2D vector graphics editor.
Allows you to create and edit simple vector graphics, such
as different geometric primitives - points, rectangles, polygons,
points, circles, ellipses. The main feature is -
all figures we placing on the picture. Thus, it
like arrangement of bands in the picture. These areas can be used
different ways:


1) You can save the area into a text file (txt, ini, xml, json), then to read with
another program. For example, your image recognition module.


2) As a background picture you can use a sequence of frames from
folder on disk or video file (avi). This can be used for cutting numbers
from video with moving automobiles or wagons (OCR).

Typical Applications:


1) Common computer vision application.
Marking rectangular areas on image (region of interst - ROI).
These regions are then used byimage processing program.


2) People detection and tracking.
Marking zones on 2D plan of room or building. For example, it may be different
sore places: market place, cashbox, showcases, enter and exit.
When tracking an object, we can analyze its coordinates (x, y) - fall
they are in a interseted area or not.


3) OCR. Cutting numbers for OCR


4) Marking the contours of objects.



