/// <reference path="../Scripts/typings/angular2/angular2.d.ts" />
/// <reference path="../Scripts/Aurora.d.ts" />
import {Component, View, bootstrap} from 'angular2/angular2';

@Component(
    {
        selector: 'lecteur'
    })
@View({
    templateUrl: 'lecteur.html'
})
class MyAppComponent {
    name: string;
    currentPlayer: AV.Player;

    constructor() {
        this.name = "Toto";
        this.currentPlayer = AV.Player.fromURL("music.flac");
    }

    public play() {
        this.currentPlayer.play();
    }

    public pause() {
        this.currentPlayer.pause();
    }

    public stop() {
        this.pause();
        this.currentPlayer.seek(0);
    }



}


bootstrap(MyAppComponent);