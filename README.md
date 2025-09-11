# uGUI SafeArea Rect

A Unity package that provides automatic safe area handling for uGUI elements.

## Overview

The SafeArea component automatically adjusts a RectTransform to fit 
within the device's safe area. This component modifies the anchor points 
of the RectTransform to ensure UI elements remain visible and accessible
within the safe area boundaries, particularly useful for devices with 
notches, rounded corners, or other screen cutouts.

## Usage

1. Add the SafeArea component to the first child of the UI Canvas
2. The component will automatically adjust the anchors to respect 
the device's safe area
3. UI elements within this RectTransform will be positioned safely 
within the visible screen area

## Important Assumptions

This component makes the following assumptions about your setup:

- **Non-scaled Canvas**: The canvas (or any parent) 
is assumed to be non-scaled
- **Canvas Render Mode**: The canvas render mode must be 
either Overlay or Camera
- **Camera Viewport**: For Camera render mode, the camera viewport 
is disregarded, and full viewport cove
