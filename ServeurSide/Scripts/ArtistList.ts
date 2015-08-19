/// <reference path="typings/angular2/angular2.d.ts" />
/// <reference path="ArtistService.ts" />
import {Component, View, bootstrap, NgFor, Inject} from 'angular2/angular2';
@Component(
    {
        selector: 'artistlist',
        hostInjector: [ArtistService]
    })
@View({
        templateUrl: 'Views/artistList.html',
        directives: [NgFor]
})
class ListOfArtists {
    artists: string[];

    constructor( @Inject(ArtistService) art: ArtistService) {
        this.artists = art.getArtists();
    }
}

bootstrap(ListOfArtists);