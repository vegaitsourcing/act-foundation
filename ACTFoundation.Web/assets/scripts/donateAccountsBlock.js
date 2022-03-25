const selectProject = () => {
    const selectedProject = document.getElementById('project-select').value;
    const newAccount = serializedProjects.find(a => selectedProject == a.Id);
    document.getElementById('recepient').innerHTML = newAccount.Recepient;
    document.getElementById('calling-number').innerHTML = newAccount.CallingModel;
    document.getElementById('reference-number').innerHTML = newAccount.CallNumber;
    document.getElementById('account').innerHTML = newAccount.Account;
}

const selectPurpose = () => {
    const selectedPurpose = document.getElementById('purpose-select').value;
    const purposeToDisplay = serializedPurposes.find(a => selectedPurpose == a.Purpose);
    document.getElementById('purpose-label').innerHTML = purposeToDisplay.Purpose;
    document.getElementById('purpose-details').innerHTML = purposeToDisplay.Description;
}