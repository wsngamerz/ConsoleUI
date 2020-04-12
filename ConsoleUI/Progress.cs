namespace ConsoleUI {
    /**
      * Progress
      *
      * A ConsoleUI Progress Bar Component
      */
    class Progress {
        private int increment;
        private int max;
        private int value;
        private int width;


        public Progress(int startValue = 0, int maxValue = 100, int increment = 1, int width = 10) {
            this.increment = increment;
            this.max = maxValue;
            this.value = startValue;
            this.width = width;
        }


        public void Increment() {
            value += increment;
        }


        public void Increment(int val) {
            value += val;
        }


        private void Draw() {

        }


        public void Show() {

        }
    }
}
