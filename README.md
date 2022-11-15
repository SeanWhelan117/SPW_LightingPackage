# SPW_LightingPackage

Link for unity package:

https://github.com/SeanWhelan117/SPW_LightingPackage.git?path=/SPWLighting/Packages/ie.setu.lighting#v0.3.1



Lighting Package user guide:
Warning: As this uses lights, the project needs to be URP.

1. Install the package in the package manager section in Unity.
2. Once it is installed navigate to packages and then lighting.
3. Inside the lighting folder enter the runtime folder. 
4. Inside here is a prefab you can use.
5. Pull the prefab into the project hierarchy.
6. Ensure there is some background to view the change in light off of. IE: A square in the background over the whole camera area.
7. Ensure the correct sorting layer is on the LightFixture and the Light2D.
8. Additionally, Ensure any global illumination light, likely called GlobalLight 2D, has an intensity of less than 1. Typically 0.1 - 0.3 looks good.
9. And that's it, it should be working.

