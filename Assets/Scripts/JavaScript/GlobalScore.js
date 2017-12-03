static var CurrentScore: int;
var InternalScore: int;

var ScoreText: GameObject;

function Update() {
    InteralScore = CurrentScore;
    ScoreText.GetComponent.<Text>().text = "" + InternalScore;
}