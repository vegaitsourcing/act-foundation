const selectProject = () => {
    const selectedProject = document.getElementById('project-select').value;
    const newAccount = serializedProjects.find(a => selectedProject == a.Id);
    document.getElementById('recepient').innerHTML = newAccount.Recepient;
    document.getElementById('calling-number').innerHTML = newAccount.CallingModel;
    document.getElementById('reference-number').innerHTML = newAccount.CallNumber;
    document.getElementById('account').innerHTML = newAccount.Account;
}