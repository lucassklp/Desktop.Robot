#import <Foundation/Foundation.h>
#include <ApplicationServices/ApplicationServices.h>
#include <unistd.h>

extern "C" {
    void setMousePosition(unsigned int x, unsigned int y){
        CGPoint point;
        point.x = x;
        point.y = y;
        //CGSetLocalEventsSuppressionInterval(0);
        CGWarpMouseCursorPosition(point);
    }

    void leftClick(unsigned int x, unsigned int y){
        CGEventRef click1_down = CGEventCreateMouseEvent(
            NULL, kCGEventLeftMouseDown,
            CGPointMake(x, y),
            kCGMouseButtonLeft
        );
        // Left button up at 250x250
        CGEventRef click1_up = CGEventCreateMouseEvent(
            NULL, kCGEventLeftMouseUp,
            CGPointMake(x, y),
            kCGMouseButtonLeft
        );
        CGEventPost(kCGHIDEventTap, click1_down);
        CGEventPost(kCGHIDEventTap, click1_up);

        // Release the events
        CFRelease(click1_up);
        CFRelease(click1_down);
    }

    void rightClick(unsigned int x, unsigned int y){
        CGEventRef click1_down = CGEventCreateMouseEvent(
            NULL, kCGEventRightMouseDown,
            CGPointMake(x, y),
            kCGMouseButtonRight
        );
        // Left button up at 250x250
        CGEventRef click1_up = CGEventCreateMouseEvent(
            NULL, kCGEventRightMouseUp,
            CGPointMake(x, y),
            kCGMouseButtonRight
        );
        CGEventPost(kCGHIDEventTap, click1_down);
        CGEventPost(kCGHIDEventTap, click1_up);

        // Release the events
        CFRelease(click1_up);
        CFRelease(click1_down);
    }
}
