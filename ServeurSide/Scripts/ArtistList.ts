/// <reference path="typings/angular2/angular2.d.ts" />
import {Component, View, bootstrap, NgFor} from 'angular2/angular2';
@Component(
    {
        selector: 'artistlist'
    })
@View({
        templateUrl: 'Views/artistList.html',
        directives: [NgFor]
})
class ListOfArtists {
    artists: string[];

    constructor() {
        this.artists = ["Test A", "Test b", "Test c"];
    }

   



}

bootstrap(ListOfArtists);