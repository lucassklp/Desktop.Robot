#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#include <ApplicationServices/ApplicationServices.h>
#include <unistd.h>

extern "C" {

    bool SHIFT_ACTIVE = false;
    bool ALT_ACTIVE = false;
    bool COMMAND_ACTIVE = false;
    bool CONTROL_ACTIVE = false;

    UInt64 flags = 0;

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
        CGEventRef saveCommandDown = CGEventCreateKeyboardEvent(source, inputKeyCode, true);

        if (inputKeyCode == 55) {
            COMMAND_ACTIVE = true;
        } else if (inputKeyCode == 59) {
            CONTROL_ACTIVE = true;
        } else if (inputKeyCode == 58) {
            ALT_ACTIVE = true;
        } else if (inputKeyCode == 56) {
            SHIFT_ACTIVE = true;
        }

        flags = 0;

        if (COMMAND_ACTIVE) {
            flags = flags | kCGEventFlagMaskCommand;
        }

        if (CONTROL_ACTIVE) {
            flags = flags | kCGEventFlagMaskControl;
        }

        if (ALT_ACTIVE) {
            flags = flags | kCGEventFlagMaskAlternate;
        }

        if (SHIFT_ACTIVE) {
            flags = flags | kCGEventFlagMaskShift;
        }

        CGEventSetFlags(saveCommandDown, flags);
        CGEventPost(kCGAnnotatedSessionEventTap, saveCommandDown);
        CFRelease(saveCommandDown);
        CFRelease(source);
    }

    void sendCommandUp(short input){

        CGKeyCode inputKeyCode = input;

        if (inputKeyCode == 55) {
            COMMAND_ACTIVE = false;
        } else if (inputKeyCode == 59) {
            CONTROL_ACTIVE = false;
        } else if (inputKeyCode == 58) {
            ALT_ACTIVE = false;
        } else if (inputKeyCode == 56) {
            SHIFT_ACTIVE = false;
        }

        flags = 0;

        if (COMMAND_ACTIVE) {
            flags = flags | kCGEventFlagMaskCommand;
        }

        if (CONTROL_ACTIVE) {
            flags = flags | kCGEventFlagMaskControl;
        }

        if (ALT_ACTIVE) {
            flags = flags | kCGEventFlagMaskAlternate;
        }

        if (SHIFT_ACTIVE) {
            flags = flags | kCGEventFlagMaskShift;
        }

        CGEventSourceRef source = CGEventSourceCreate(kCGEventSourceStateCombinedSessionState);
        CGEventRef saveCommandUp = CGEventCreateKeyboardEvent(source, inputKeyCode, false);
        CGEventSetFlags(saveCommandUp, flags);
        CGEventPost(kCGAnnotatedSessionEventTap, saveCommandUp);
        CFRelease(saveCommandUp);
        CFRelease(source);
    }

    void sendCommand(short input){
        sendCommandDown(input);
        sendCommandUp(input);
    }
}
