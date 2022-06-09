//One way to configurate of parallism

//This is not recomended
//default behavior
//[assembly : CollectionBehavior(CollectionBehavior.CollectionPerClass)]

//per assembly
//[assembly : CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

//Disabling the parallelization
//maybe usefull if we have one instance of database .....
//[assembly : CollectionBehavior(DisableTestParallelization = true)]

//[assembly : CollectionBehavior(MaxParallelThreads = 1)]