Scrum 1 Summary (03/02/20)

Opening:

  Scrum master (Jason) briefly covered the feedback given from sprint 1, reminding the group of the information covered in the sprint 1 retrospective. "Aims for Sprint 2" were talked about, ensuring everybody was on the same page for what we need to do differently in this sprint. 
  Brief overview of feedback from client meeting was also covered. 

Jason:

  Have done:
    Started writing tests for allowing the user to change the fint, increasing the accessibility of our solution
  Will do:
    Implement the font changing functionality, as well as hoping to look into other ways of making the user interface more accessible. Will also look into using XUnit within Windows Forms, so to improve the unit testing
   
Melvin:

  Have done:
    Typed up the burndown chart and inputted the user stories, as well as breaking down the user stories into tasks to be completed. Also carried out research on how to find the users live location
  Will do:
    Find a way of the live location and changing this into an address for us to use in our solution. Next steps would be helping to implement this
  
Lin:

  Have done:
    Looked into redesigning the user interface, and crceating rough sketches to reflect this.
  Will do:
    Give the user interface redesign a more polished look, as well as looking into the functionality behind swapping between pages
  
Paul:

  Have done:
    Completed test plan for search procedure. Once implemented, this will allow the user to search for procedures by a description, instead of the medical code
  Will do:
    Implement the given tests, and work towards providing this as a completed solution
  
Kyle:

  Have done:
    Researched how to display search results in a list box, in an effort to clean up this section (as asked by clients in the client meeting)
  Will do:
  Implement the list box feature, as well researching and implementing a method of allowing the user to select one of the returned  options
  
Arran:

  Have done:
    Began spike project researching how to find the distance between two points in the map. 
  Will do:
    Research into finding routes between points, as this will help in finding the distance. Then can work with Kyle to use the hospital address data to find the distance between those and the point given by the user. 
  
Closing:

  Reminding the group to help eachother where possible. If you find a resource that may be helpful to others, share it on the Slack. Examples of this already happening were given (Arran sharing map resources to Melvin, Jason sharing unit testing resources). 
  
  
Scrum 2 (04/02/20)

Jason:

  Have done:
    Worked on adding accessibility features. Tests have been written, and basic methods created. Also done some work trying to implement continuous integration using GitHub workflow, but ran into problems and couldn't complete this. 
  Will do:
    Need to combine the accessibility features into the final UI. Can do this once map functionality and UI are finalised
  Problems:
    Having trouble with the CI in GitHub workflows, YML script fails to build the solution. This has put to the side to hopefull come back to later. 
    
Melvin:

  Have done:
    Working functionality using the users live location, taking in the GPS of the current device. This returns a latitude and longitude, which can later be used with the map features
  Will do:
    Update sprint backlog with the teams work from today, and combine live location functionality with map once it has been finalised. 

Paul:

  Have done:
    Completed tests for the search functionality, and written the code to pass the tests. Matches are returned as a list
  Will do:
    Need to combine this functionality with the UI once finalised by Lin
    
Arran:

  Have done:
    Finished spike research about finding distance between points. Have also finished research with creating routes between two points on the map, and displaying these. Tests have begun to be written for adding this function
  Will do:
    Finish tests and implement routing feature. Work with Kyle to combine routing with the hospital addresses returned by his search procedure
    
Lin:

Have done:
  Finished design of UI, and started implementing this into a windows forms application
Will do:
  Once this is finished, will need to take feedback from the team to ensure UI is suitable for each aspect of the product. May need to change parts, depending on how the team feels
  
Kyle:

  Have done:
    Researched how to let user choose specific hospital result from dropdown list. 
  Will do:
    Begin test driven development for having hospitals being disaplyed on the map. Will work with Arran

Scrum 3 (05/02/20)

Opening Remarks:
  "We're in the endgame now" - Scrum Master
  
Jason:
  Have done:
    Worked to fix the issues with continuous integration. Used GitLab to help with this. GitLab linked to the GitHub, then wrote the YML file
  Will do:
    Overlook UI development, as the requirements have been changing so the UI must reflect this. Can also help anyone if help is needed. Control flow of merging branches while integrating features, to ensure git is used correctly.
    
Melvin:
  Have done:
    Completed finishing touches on user live location functions
  Will do:
    Once UI is finished, will need to integrate live location function with this. Will also update burndown chart for the day
    
Kyle:
  Have done:
    Worked with Arran in getting the hospitals displayed on the map
  Will do:
    Must put this with UI once it is finished
    
Paul:
  Have done:
    Added more functionality to search procedure. When multiple similar results are shown, these are combined into one. Also now each hospital is only displayed once
  Will do:
    Need to start creating a test plan, tests and then writing the code for returning values that are not in file. For example, if the user inputs nose bleed, epistaxis will be returned. 
    
Arran:
  Have done:
    Wrote implementation of finding distance between two points. Worked with Kyle to display returned hospitals on the map. 
  Will do:
    Add functionality to find distances to each hospital and draw a route for the selected hospital
    
Lin:
  Have done:
    Changed the UI according to team feedback
  Will do:
    May have to change the UI further during collaboration, as team members insert their code into UI
  
Scrum 4 (06/02/20)

Opening:
  Scrum master letting team know that the GitHub flow was good today, better than in previous sprint.

Jason:
  Have done:
    Jason has been supervising the integration and overseeing Kyle and Arran with their Git usage. Has also been approving pull requests, and making sure code  is ready for merging with higher branches. Also filmed the TTD video
  Will do:
    Focus being placed on deliverables, must ensure sprint review report is finished and ready to submit
    
Paul:
  Have done:
    Completed search function, allowing users to search by laymans terms and having relevant results returned
  Will do:
    Integrate with UI
    
Kyle:
  Have done:
    Working with Arran, integrating map and distance range functions into new UI
  Will do:
    Additional functionality to be added to final UI. Option for user to select hospital
    
Melvin:
  Have done:
    Filmed TDD video, and wrote report for TDD
  Will do:
    Integrate sort by distance and live location functions into final UI
    
Lin:
  Have done:
    Finished UI according to team feedback
  Will do:
  
Arran:
  Have done:
    Working with Kyle, integrated map and distance range functions into new UI
  Will do:
    Additional functionality to be added to final UI. Showing users chosen hospital on map with route drawn
    
Closing:
  Be careful with merging on Git. To implement by priority: distance shown, search feature, live location. If we run out of time it is okay, as clients have told us what to prioritise
  
  
Scrum 5 (07/02/20)
Opening:
  We ave our demo sorted and working, progress has been really good. Now we have to go to client meeting, remember to all be professional and polite

Jason:
  Supervising Git flow, and ensuring inegration goes smoothly

Lin:
  Helped with UI implementation/integration

Paul:
  Integrated search by laymans terms function. Allows user to enter english words as input, as opposed to medical code for the procedure. If multiple procedures may apply, then all are returned and the user can select which they want

Melvin:
  Integrate order results by distance/price into final UI

Kyle:
  Finished UI changes. Made hospital results shown in labels with buttons, so as easier to see. Also integrated distance changes

Arran:
  Added functionality for user to request a route to be shown between their location and their selected hospital.

Close:
  Happy with everyones work, lets go over our process/prep for the client meeting again before heading up. 
  
No additional features/tasks have been given to each team member, but if there was anther sprint then this would be done. After speaking to the clients, these are the other tasks we would tackle:
  Finish live location and accessibility integration. Start functionality for method of editing dataset (add/delete/edit), and start functionality for allowing users to give a custom ranking. We would also show distances of hospitals on the map, as well as giving tooltips on the map to show further info. We could also add a feature to allow users the ability to adjust the current filter while on the map screen, to save them moving between screens so much.
