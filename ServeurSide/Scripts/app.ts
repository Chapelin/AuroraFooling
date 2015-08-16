
var player: AV.Player;
player = AV.Player.fromURL("http://localhost:50522/Content/music.flac");

function Launch(url: string) {

    player = AV.Player.fromURL(url);
    player.play();
}