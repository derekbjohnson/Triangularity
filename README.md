# Triangularity
Exploring The Joys of Triangles

# Task 1.A
Calculate the triangle coordinates for an image with right triangles such that for a given row (A-F) and column (1-12) you can produce any of the triangles.

## API usage: /api/triangulator/{row}/{column}

* Example: /api/triangulator/b/3
* Produces: {10,20} {10,10} {20,20}

# Task 1.B
Given the vertex coordinates, calculate the row and column for the triangle.

## API usage: /api/triangulator/{v1x}/{v1y}/{v2x}/{v2y}/{v3x}/{v3y}

* Example: /api/triangulator/10/20/10/10/20/20
* Produces: "The Triangle is at C10"

# Remaining work:
* ~~Validation of coordinates~~
* ~~Initial xUnit Tests~~
* Documentation that's not terrible
* UI in Blazor
* Get app running on Azure
