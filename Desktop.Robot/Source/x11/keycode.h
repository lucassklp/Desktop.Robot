#include <X11/XF86keysym.h>
#include <X11/Xutil.h>

struct XSpecialCharacterMapping {
	char name;
	KeySym code;
};

struct XSpecialCharacterMapping XSpecialCharacterTable[] = {
    {'~', XK_asciitilde},
    {'_', XK_underscore},
    {'[', XK_bracketleft},
    {']', XK_bracketright},
    {'!', XK_exclam},
    {'\'', XK_quotedbl},
    {'#', XK_numbersign},
    {'$', XK_dollar},
    {'%', XK_percent},
    {'&', XK_ampersand},
    {'\'', XK_quoteright},
    {'*', XK_asterisk},
    {'+', XK_plus},
    {',', XK_comma},
    {'-', XK_minus},
    {'.', XK_period},
    {'?', XK_question},
    {'<', XK_less},
    {'>', XK_greater},
    {'=', XK_equal},
    {'@', XK_at},
    {':', XK_colon},
    {';', XK_semicolon},
    {'\\', XK_backslash},
    {'`', XK_grave},
    {'{', XK_braceleft},
    {'}', XK_braceright},
    {'|', XK_bar},
    {'^', XK_asciicircum},
    {'(', XK_parenleft},
    {')', XK_parenright},
    {' ', XK_space},
    {'/', XK_slash},
    {'\t', XK_Tab},
    {'\n', XK_Return}
};