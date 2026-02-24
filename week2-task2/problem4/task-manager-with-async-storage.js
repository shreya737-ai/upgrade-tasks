let tasks = [];
const addTaskCallback = (taskName, callback) => {
  setTimeout(() => {
    tasks.push(taskName);
    callback(`Task "${taskName}" added (Callback Version)`);
  }, 1000);
};

const deleteTaskCallback = (taskName, callback) => {
  setTimeout(() => {
    tasks = tasks.filter(task => task !== taskName);
    callback(`Task "${taskName}" deleted (Callback Version)`);
  }, 1000);
};

const addTaskPromise = (taskName) => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (!taskName) {
        reject(new Error("Task name cannot be empty"));
      } else {
        tasks.push(taskName);
        resolve(`Task "${taskName}" added (Promise Version)`);
      }
    }, 1000);
  });
};

const deleteTaskPromise = (taskName) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks = tasks.filter(task => task !== taskName);
      resolve(`Task "${taskName}" deleted (Promise Version)`);
    }, 1000);
  });
};

const addTaskAsync = async (taskName) => {
  try {
    const message = await addTaskPromise(taskName);
    return message;
  } catch (error) {
    throw error;
  }
};

const deleteTaskAsync = async (taskName) => {
  const message = await deleteTaskPromise(taskName);
  return message;
};


const listTasks = () => {
  console.log(" Current Tasks:");
  if (tasks.length === 0) {
    console.log("No tasks available.");
  } else {
    tasks.forEach((task, index) =>
      console.log(`${index + 1}. ${task}`)
    );
  }
  console.log("----------------------------------\n");
};

console.log("===== CALLBACK DEMO =====");

addTaskCallback("Learn JavaScript", (msg) => {
  console.log(msg);
  listTasks();

  deleteTaskCallback("Learn JavaScript", (msg) => {
    console.log(msg);
    listTasks();

    console.log("===== PROMISE DEMO =====");

    addTaskPromise("Learn Promises")
      .then((msg) => {
        console.log(msg);
        listTasks();
        return deleteTaskPromise("Learn Promises");
      })
      .then((msg) => {
        console.log(msg);
        listTasks();

        console.log("===== ASYNC/AWAIT DEMO =====");

        runAsyncDemo();
      })
      .catch((error) => console.error(` ${error.message}`));
  });
});


const runAsyncDemo = async () => {
  try {
    const addMsg = await addTaskAsync("Master Async/Await");
    console.log(addMsg);
    listTasks();

    const deleteMsg = await deleteTaskAsync("Master Async/Await");
    console.log(deleteMsg);
    listTasks();
  } catch (error) {
    console.error(`Error: ${error.message}`);
  }
};