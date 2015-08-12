declare module AV {

    export class Player {
        public preload();
        public play();
        public pause();
        public tooglePlayback();
        public stop();
        public seek(timeStamp: number): number;

        public duration: number;
        public currentTime: number;
        public volume: number;
        public playing: boolean;
        public pan: number;

        public static fromURL(url: string): Player;
        public static fromFile(file: string): Player;
        public static fromBuffer(buffer: ArrayBuffer);
    }


}

