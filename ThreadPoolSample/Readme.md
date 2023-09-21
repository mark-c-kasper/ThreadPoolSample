# Purpose

The intent of this tiny solution is to just demo a use-case for the ThreadPool class in C#.
This class can be handy in the event of needing to do a lot of repeated work that can be pushed off of the main thread and onto background threads.

This was a situation I had come across a few times.
- The first case was in the event of not being able to use a Cron-Job to execute a console application.
- The second was a service that was doing a lot of background work with their own Threading.
I do believe a better solution for this situation was to change their direction and use a pub/sub model. 

The two demo's that are run are broken into Synchronous and Asynchronous batches just to demonstrate the time it takes to process each.