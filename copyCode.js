window.copyCode = function (text) {

    const textarea = document.createElement('textarea');
    textarea.value = text;
    textarea.style.position = 'fixed';  // To prevent scrolling when focusing on the textarea
    document.body.appendChild(textarea);
    textarea.select();

    try {
        const successful = document.execCommand('copy');
        const message = successful ? 'Text copied to clipboard' : 'Unable to copy text';
        console.log(message);
    } catch (err) {
        console.error('Error copying text:', err);
    }

    document.body.removeChild(textarea);  // Remove the textarea
}