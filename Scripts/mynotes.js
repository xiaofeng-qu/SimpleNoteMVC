$(function(){
    // define variables
    var activeNote = 0;
    var editMode = false;

    // add a new note
    $('#addNote').click(function () {
        $.ajax({
            url: "",
            success: function () {
                showHide(['#notePad', '#allNotes'], ['#notes', '#addNote', '#edit', '#done']);
                $('#notePadTextarea').focus();
            }
        });
    });
    
    
    // type note: Ajax call to updatenote.php
    $("#noteContentForm").submit(function(){
        updateNote();        
    });
    
    // click on all notes button
    $('#allNotes').click(function(){
        showHide(["#addNote", "#edit", "#notes"], ["#allNotes", "#notePad", "#done"]);
    });
    
    // click on done button
    $('#done').click(function(){
        window.location = "/Note/Index";
    });

    // edit button
    $('#edit').click(function(){
        editMode = true;
        // Add classes to notes
        $('.well').addClass("col-xs-7 col-sm-9");
        // Show hide elements
        showHide(["#done", ".delete"], [this]);
    });
    
    // Speech input
    $('#speechInput').click(function(){
        if(window.hasOwnProperty('webkitSpeechRecognition')){
            var recognition = new webkitSpeechRecognition();
            
            recognition.continuous = false;
            recognition.interimResults = false;
            
            recognition.lang = "en-US";
            recognition.start();
            
            recognition.onresult = function(e){
                $("#notePadTextarea").val($("#notePadTextarea").val() + e.results[0][0].transcript);
                recognition.stop();
                updateNote();
            }
            recognition.onerror = function(e) {
                recognition.stop();
            }
        }
    });
    
    // delete button
    $('.delete').click(function(){
        var deleteButton = $(this);
        $.ajax({
            url: "/Note/Delete",
            type: "Post",
            data: { id: deleteButton.next().attr('id') },
            success: function () {
                deleteButton.parent().remove();
            }
        });
    });
    
    // click the note
    $(".well").click(function(){
        if(!editMode){
            // collect active note id
            activeNote = $(this).attr("id");
            // fill the textarea
            $("#notePadTextarea").val($(this).find(".text").text());
            showHide(['#notePad', '#allNotes'], ['#notes', '#addNote', '#edit', '#done']);
            $('#notePadTextarea').focus();
        }
    });
    
    // Show hide elements
    function showHide(array1, array2){
        for(i = 0; i < array1.length; i++){
            $(array1[i]).show();
        }
        for(i = 0; i < array2.length; i++){
            $(array2[i]).hide();
        }
    }
    
    // Function to update notes
    function updateNote(){
        var theTextarea = $('#notePadTextarea');
        $.ajax({
            url: "/Note/Update",
            type: "POST",
            data: { note: theTextarea.val(), id: activeNote },
            success: function () {
                activeNote = 0;
            }
        });
    }
    
});
