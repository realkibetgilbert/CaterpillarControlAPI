# CATERPILLAR CONTROL API


This can also be tested using Postman.

### Built With

# Installing .NET 6

- [Downloads](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Installation docs](https://docs.microsoft.com/dotnet/core/install/)
- [Install Visual studio](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022)


## Getting Started

## Installation

1. Clone the repo
https://github.com/realkibetgilbert/CaterpillarControlAPI.git
2. Make sure you have followed the above steps to install .NET 6 and visual studio on your machine

3. Navigate to the .sln file and click on it it will open the solution on visual studio

4. Restore the dependencies 

5. Start the application  the application will migrate on starup and . Navigate to your URL/swagger and you will have the UI documenting the API

## Usage
You will first login to get the access token
Use rider@gmail.com as email and !!rider@ as password

Authorize the caterpillar endpoint using the Bearer the token you generated on login for example Bearer LCK1AsfBL4JVHPc8u8toyfkeUz2KkotLu40R004OVSfKk2iK1Zd3vvfwV4gXilGD

Once you login you can view the existing caterpillar details using the endpoint /api/Caterpillar/get-caterpillars

You can  change the caterpillar position using the endpoint api/Caterpillar/move/1

You can grow and shrink caterpillar length using the endpoint /api/Caterpillar/grow-shrink/1


## Contact

GilbertKibet: kibetgilly354@gmail.com
