var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent;
document.recognition = new SpeechRecognition();

document.recognition.continuous = false;
document.recognition.lang = 'ru-RU';
document.recognition.interimResults = false;
document.recognition.maxAlternatives = 1;

document.recognition.onspeechend = function () {
    document.recognition.stop();
}

document.recognition.onnomatch = function (event) {
    console.log("I didn't recognise that word.");
}

document.recognition.onerror = function (event) {
    console.log('Error occurred in recognition: ' + event.error);
}
