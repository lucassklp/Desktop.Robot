#include <X11/Xlib.h>
#include <stdlib.h>
#include "xdisplay.c"
#include <X11/extensions/XTest.h>
#include <sstream>
#include "keycode.h"
#include <X11/XF86keysym.h>

using namespace std;

extern "C" {

    void moveMouse(int x, int y)
    {
        Display *display = XGetMainDisplay();
	    XWarpPointer(display, None, DefaultRootWindow(display), 0, 0, 0, 0, x, y);
	    XSync(display, false);
    }

    void click(bool down, int button){
        Display *display = XGetMainDisplay();
        XTestFakeButtonEvent(display, button, down ? True : False, CurrentTime);
        XSync(display, false);
    }

    char* getMousePosition(){
        XInitThreads();

        int x, y; /* This is all we care about. Seriously. */
        Window garb1, garb2; /* Why you can't specify NULL as a parameter */
        int garb_x, garb_y;  /* is beyond me. */
        unsigned int more_garbage;

        Display *display = XGetMainDisplay();
        XQueryPointer(display, XDefaultRootWindow(display), &garb1, &garb2,
                    &x, &y, &garb_x, &garb_y, &more_garbage);

        string res = to_string(x) + "x" + to_string(y);
        char* ret = strdup(res.c_str());

        return ret;
    }

    KeySym keyCodeForChar(char c) {
        KeySym code;

        char buf[2];
        buf[0] = c;
        buf[1] = '\0';

        code = XStringToKeysym(buf);
        if (code == NoSymbol) {
            /* Some special keys are apparently not handled properly by
            * XStringToKeysym() on some systems, so search for them instead in our
            * mapping table. */
            size_t i;
            const size_t specialCharacterCount =
                sizeof(XSpecialCharacterTable) / sizeof(XSpecialCharacterTable[0]);
            for (i = 0; i < specialCharacterCount; ++i) {
                if (c == XSpecialCharacterTable[i].name) {
                    code = XSpecialCharacterTable[i].code;
                    break;
                }
            }
        }

        return code;
    }

    void xKeyEvent(Display *display, KeySym key, bool down){
        const Bool is_press = down ? True : False;

        XTestFakeKeyEvent(display,
            XKeysymToKeycode(display, key),
            is_press,
            CurrentTime
        );

        XSync(display, false);
    }

    void pressKeyCode(KeySym code, bool down, int flags){
        Display *display = XGetMainDisplay();
	    const Bool is_press = down ? True : False;

        if (down) {
            if (flags & Mod4Mask) xKeyEvent(display, XK_Super_L, is_press);
            if (flags & Mod1Mask) xKeyEvent(display, XK_Alt_L, is_press);
            if (flags & ControlMask) xKeyEvent(display, XK_Control_L, is_press);
            if (flags & ShiftMask) xKeyEvent(display, XK_Shift_L, is_press);

            xKeyEvent(display, code, is_press);
        } else {
            xKeyEvent(display, code, is_press);

            if (flags & Mod4Mask) xKeyEvent(display, XK_Super_L, is_press);
            if (flags & Mod1Mask) xKeyEvent(display, XK_Alt_L, is_press);
            if (flags & ControlMask) xKeyEvent(display, XK_Control_L, is_press);
            if (flags & ShiftMask) xKeyEvent(display, XK_Shift_L, is_press);
        }
    }

    void pressKey(char c, bool down, int flags) {
        KeySym keyCode = keyCodeForChar(c);
	    pressKeyCode(keyCode, down, flags);
    }
}
