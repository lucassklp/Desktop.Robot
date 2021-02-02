#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#include <ApplicationServices/ApplicationServices.h>
#include <unistd.h>

extern "C" {
    void setMousePosition(unsigned int x, unsigned int y){
        CGPoint point;
        point.x = x;
        point.y = y;
        CGWarpMouseCursorPosition(point);
    }

    void leftMouseDown(unsigned int x, unsigned int y){
        CGEventRef mouseDown = CGEventCreateMouseEvent(
            NULL, kCGEventLeftMouseDown,
            CGPointMake(x, y),
            kCGMouseButtonLeft
        );
        CGEventPost(kCGHIDEventTap, mouseDown);
        CFRelease(mouseDown);
    }

    void leftMouseUp(unsigned int x, unsigned int y){
        CGEventRef mouseUp = CGEventCreateMouseEvent(
            NULL, kCGEventLeftMouseUp,
            CGPointMake(x, y),
            kCGMouseButtonLeft
        );
        CGEventPost(kCGHIDEventTap, mouseUp);
        CFRelease(mouseUp);
    }

    void rightMouseDown(unsigned int x, unsigned int y){
        CGEventRef mouseDown = CGEventCreateMouseEvent(
            NULL, kCGEventRightMouseDown,
            CGPointMake(x, y),
            kCGMouseButtonRight
        );
        CGEventPost(kCGHIDEventTap, mouseDown);
        CFRelease(mouseDown);
    }

    void rightMouseUp(unsigned int x, unsigned int y){
        CGEventRef mouseUp = CGEventCreateMouseEvent(
            NULL, kCGEventRightMouseUp,
            CGPointMake(x, y),
            kCGMouseButtonRight
        );
        CGEventPost(kCGHIDEventTap, mouseUp);
        CFRelease(mouseUp);
    }

    void leftClick(unsigned int x, unsigned int y){
        leftMouseDown(x, y);
        leftMouseUp(x, y);
    }

    void rightClick(unsigned int x, unsigned int y){
        rightMouseDown(x, y);
        rightMouseUp(x, y);
    }

    char* getMousePosition(){
        NSPoint mouseLoc = [NSEvent mouseLocation];
        NSString* pos = [NSString stringWithFormat:@"%.0f;%.0f", mouseLoc.x, mouseLoc.y];
        return (char*)[pos UTF8String];
    }

    char* screenResolution() {
        NSScreen* thescreen;
        id theScreens = [NSScreen screens];

        NSString * ret;
        for (thescreen in theScreens) {
            ret = [NSString stringWithFormat:@"%@x%@", [NSNumber numberWithFloat:[thescreen frame].size.width], [NSNumber numberWithFloat:[thescreen frame].size.height]];
        }
        return (char*)[ret UTF8String];
    }

    void keyDown(char ch){
        CGEventRef downEvt = CGEventCreateKeyboardEvent(NULL, 0, true);
        UniChar oneChar = ch;
        CGEventKeyboardSetUnicodeString(downEvt, 1, &oneChar);
        CGEventPost(kCGAnnotatedSessionEventTap, downEvt);
    }

    void keyUp(char ch){
        CGEventRef upEvt = CGEventCreateKeyboardEvent(NULL, 0, false);
        UniChar oneChar = ch;
        CGEventKeyboardSetUnicodeString(upEvt, 1, &oneChar);
        CGEventPost(kCGAnnotatedSessionEventTap, upEvt);
    }

    void keyPress(char ch){
        keyDown(ch);
        keyUp(ch);
    }

    void sendCommandDown(short input){
        CGKeyCode inputKeyCode = input;
        CGEventSourceRef source = CGEventSourceCreate(kCGEventSourceStateCombinedSessionState);
        CGEventRef saveCommandDown = CGEventCreateKeyboardEvent(source, inputKeyCode, YES);
        CGEventSetFlags(saveCommandDown, kCGEventFlagMaskCommand);
        CGEventPost(kCGAnnotatedSessionEventTap, saveCommandDown);
        CFRelease(saveCommandDown);
        CFRelease(source);
    }

    void sendCommandUp(short input){
        CGKeyCode inputKeyCode = input;
        CGEventSourceRef source = CGEventSourceCreate(kCGEventSourceStateCombinedSessionState);
        CGEventRef saveCommandUp = CGEventCreateKeyboardEvent(source, inputKeyCode, NO);
        CGEventPost(kCGAnnotatedSessionEventTap, saveCommandUp);
        CFRelease(saveCommandUp);
        CFRelease(source);
    }

    void sendCommand(short input){
        sendCommandDown(input);
        sendCommandUp(input);
    }

    // void combineCommand(short[] inputs){

        

    //     CGKeyCode inputKeyCode = input;
    //     CGEventSourceRef source = CGEventSourceCreate(kCGEventSourceStateCombinedSessionState);
    //     CGEventRef saveCommandUp = CGEventCreateKeyboardEvent(source, inputKeyCode, NO);
    //     CGEventPost(kCGAnnotatedSessionEventTap, saveCommandUp);
    //     CFRelease(saveCommandUp);
    // }
}
