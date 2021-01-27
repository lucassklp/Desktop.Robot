namespace System.Robot {
    public static class Robot {
        public static IRobot Create(){
            return new OSXRobot();
        }
    }
}