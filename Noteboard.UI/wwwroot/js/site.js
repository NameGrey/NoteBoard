var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent;
var recognition = new SpeechRecognition();

recognition.continuous = false;
recognition.lang = 'ru-RU';
recognition.interimResults = false;
recognition.maxAlternatives = 1;

recognition.onresult = function (event) {
    var word = event.results[0][0].transcript;
    console.log('Result received: ' + word + '.');
}

recognition.onspeechend = function () {
    recognition.stop();
}

recognition.onnomatch = function (event) {
    console.log("I didn't recognise that word.");
}

recognition.onerror = function (event) {
    console.log('Error occurred in recognition: ' + event.error);
}

var micButton = document.getElementById("mic-button");

if (micButton) {
    micButton.onclick = function() {
        recognition.start();
        console.log('Start recognition.');
    }
}