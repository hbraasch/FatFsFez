FatFsFez<br>
c# port of FastFs for GHI FEZ<br> 
Works good enough for me. Please use at own risk<br>
To keep the port simple I only ported for short filenames<br>
It uses the FEZ SPI hardware. It does not use the CS pin as setup for the SPI driver. I am using a seperate GPIO pin to chip select because the SD card needs more versatile chip select<br>
See FatFsFezSchematic.jpg for wiring.
