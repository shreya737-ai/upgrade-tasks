function saveNote() {
    const input = document.getElementById('noteInput'); 
    const noteValue = input.value; 

    localStorage.setItem('personalNote', noteValue);
    displayNote();

    input.value = ""; 
}

function clearInput() {
     
        document.getElementById('noteInput').value = "";
        localStorage.removeItem('personalNote');
        document.getElementById('notesList').innerHTML = "";
        alert('Note cleared!');
        

}
 function displayNote() {
    const savedNote = localStorage.getItem('personalNote');
    if (savedNote) {
        const notesList = document.getElementById('notesList');
        const listItem = document.createElement('p');
        listItem.textContent = savedNote;
        notesList.appendChild(listItem);
    }   
}
