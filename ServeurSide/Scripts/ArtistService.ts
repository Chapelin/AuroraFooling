class ArtistService {

    artistList :string[];

    constructor() {
        this.artistList = ["Artist1", "Artist2", "Artist3", "Artist4", "Artist5", "Artist6"];
    }

    public getArtists(): string[]{
        return this.artistList;
    }
}