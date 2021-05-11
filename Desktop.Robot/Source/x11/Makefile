CC=gcc -shared
FRAMEWORKS:= -L/usr/X11/lib
OPTIONS:= -lX11 -lstdc++ -fPIC -lXtst
SOURCE=main.cpp
OUT=-o ../../x11.os
all:
	$(CC) $(SOURCE) $(OUT) $(FRAMEWORKS) $(OPTIONS)