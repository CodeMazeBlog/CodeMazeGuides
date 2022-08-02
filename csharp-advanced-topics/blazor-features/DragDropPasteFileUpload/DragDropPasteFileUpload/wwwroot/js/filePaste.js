export function initializeFilePaste(fileDropContainer, inputFile) {

    function onPaste(e) {
        inputFile.files = e.clipboardData.files;
        const event = new Event('change', { bubbles: true });
        inputFile.dispatchEvent(event);
    }

    fileDropContainer.addEventListener('paste', onPaste);

    return {
        dispose: () => {
            fileDropContainer.removeEventListener('paste', onPaste);
        }
    }
}