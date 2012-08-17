zedboard_oled_util
==================

Small utility to convert .png to .bin and .bin to .png to be used to display images on the oled display on the Zedboard

Input png files must be 128x32 in size.  All white pixels (RGB = 0xFFFFFF) will show as black on the display.  All other 
colors will show as illuminated.