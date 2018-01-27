'use strict';

let canvas = document.getElementById('canvasForDigit');
let bufferCanvas = document.getElementById('bufferCanvas');
let context = canvas.getContext('2d');
let bufferContext = bufferCanvas.getContext('2d');
let result = document.getElementById('result');
let mousePressed = false;
let lastX, lastY;

context.lineWidth = 15;
context.lineJoin = context.lineCap = 'round';

canvas.onmousedown = e => mousePressed = true;
canvas.onmouseup = e => mousePressed = false;
canvas.onmouseleave = e => mousePressed = false;
canvas.onmousemove = e => {
    let x = e.pageX;
    let y = e.pageY;
    if(mousePressed) {
        draw(x, y);       
    }
    lastX = x;
    lastY = y;
}

function draw(x, y) {    
    context.beginPath();
    context.moveTo(lastX, lastY);
    context.lineTo(x, y);
    context.stroke(); 
    context.closePath();           
}

document.getElementById('clear').onclick = e => {
    context.clearRect(0, 0, canvas.width, canvas.height);
    bufferContext.clearRect(0, 0, bufferCanvas.width, bufferCanvas.height);
    result.innerText = '';
}

document.getElementById('recognise').onclick = e => {    
    let xhr = new XMLHttpRequest();
    xhr.open('POST', 'api/digit', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onreadystatechange = function () {
        if (this.readyState != 4) return;
        result.innerText = this.response;
    }
    
    //bufferContext.scale(0.1, 0.1);
    bufferContext.drawImage(canvas, 0, 0, bufferCanvas.width, bufferCanvas.height);

    let img = bufferContext.getImageData(0, 0, bufferCanvas.width, bufferCanvas.height);

    let any = false;
    let arr = [];
    let lenght = img.data.length;
    for(let i = 0; i < lenght; i++) {
        if(img.data[i] != 0){
            any = true;
        }
        if((i + 1) % 4 == 0){
            arr.push(any ? 1 : 0);
        }
        any = false;
    }
    xhr.send(JSON.stringify(arr));
}

